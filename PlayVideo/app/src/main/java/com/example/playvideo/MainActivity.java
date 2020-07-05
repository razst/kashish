package com.example.playvideo;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.media.browse.MediaBrowser;
import android.net.Uri;
import android.os.Build;
import android.os.Bundle;
import android.provider.MediaStore;
import android.support.v4.media.MediaBrowserCompat;
import android.support.v4.media.session.MediaControllerCompat;
import android.support.v4.media.session.MediaSessionCompat;
import android.support.v4.media.session.PlaybackStateCompat;
import android.util.Log;
import android.view.KeyEvent;
import android.view.Window;
import android.widget.VideoView;

import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;
import com.google.firebase.Timestamp;
import com.google.firebase.firestore.DocumentChange;
import com.google.firebase.firestore.DocumentReference;
import com.google.firebase.firestore.DocumentSnapshot;
import com.google.firebase.firestore.FirebaseFirestore;
import com.google.firebase.firestore.QueryDocumentSnapshot;
import com.google.firebase.firestore.QuerySnapshot;
import com.google.firebase.firestore.Source;

import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.time.Instant;
import java.util.Objects;

import static android.media.session.MediaSession.FLAG_HANDLES_MEDIA_BUTTONS;
import static android.view.View.SYSTEM_UI_FLAG_FULLSCREEN;
import static android.view.View.SYSTEM_UI_FLAG_HIDE_NAVIGATION;


public class MainActivity extends AppCompatActivity {

    static VideoView mVideoView = null;
    final String TAG = "fire store data";
    final int LATE_TIME = 900;//time in second that the kashish can late and the video play any ways
    final String NOT_FOUND = "not Found";
    private String myUrl = NOT_FOUND;
    MediaSessionCompat mediaSession;
    PlaybackStateCompat.Builder stateBuilder;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        requestWindowFeature(Window.FEATURE_NO_TITLE);//will hide the title
        Objects.requireNonNull(getSupportActionBar()).hide(); //hide the title bar
        FirebaseFirestore db = FirebaseFirestore.getInstance();

        Log.d(TAG,  "1" );
        getUrl(db);
        Log.d(TAG,  "2" );

        mediaSession = new MediaSessionCompat(this, TAG);

        /* Enable callbacks from MediaButtons and TransportControls
        mediaSession.setFlags(
                MediaSessionCompat.FLAG_HANDLES_MEDIA_BUTTONS |
                        MediaSessionCompat.FLAG_HANDLES_TRANSPORT_CONTROLS);
*/
        // Do not let MediaButtons restart the player when the app is not visible
//        mediaSession.setMediaButtonReceiver(null);
        // Set an initial PlaybackState with ACTION_PLAY, so media buttons can start the player
        stateBuilder = new PlaybackStateCompat.Builder()
                .setActions(
                        PlaybackStateCompat.ACTION_PLAY |
                                PlaybackStateCompat.ACTION_PLAY_PAUSE);
        mediaSession.setPlaybackState(stateBuilder.build());

        //mediaSession.setState(stateBuilder.build());


        // MySessionCallback has methods that handle callbacks from a media controller
        mediaSession.setCallback(mMediaSessionCallback);

         //Create a MediaControllerCompat
        MediaControllerCompat mediaController =
                new MediaControllerCompat(this, mediaSession);

        MediaControllerCompat.setMediaController(this, mediaController);

        mediaSession.setActive(true);



    }

    public void getUrl(FirebaseFirestore db) {
        myUrl = NOT_FOUND;
        db.collection("timetable")
                .get()
                .addOnCompleteListener(task -> {
                    if (task.isSuccessful()) {
                        for (QueryDocumentSnapshot document : Objects.requireNonNull(task.getResult())) {
                            if(videoNow((Timestamp) Objects.requireNonNull(document.getData().get("startTime")))){
                                myUrl = (String) document.getData().get("URL");
                                assert myUrl != null;
                                Log.d(TAG, myUrl);
                                break;
                            }
                            else {
                                Log.d(TAG, videoNow((Timestamp) Objects.requireNonNull(document.getData().get("startTime")))+"");
                            }
                            Log.d(TAG, document.getId() + " => " + document.getData());
                        }
                    } else {
                        Log.w(TAG, "Error getting documents.", task.getException());
                    }
                    playVideo();
                });
    }

    private MediaSessionCompat.Callback mMediaSessionCallback = new MediaSessionCompat.Callback() {

        @Override
        public void onPlay() {
            super.onPlay();
            if (mVideoView != null) {
                setContentView(R.layout.activity_main);
                mVideoView = findViewById(R.id.videoview);
                mVideoView.setSystemUiVisibility(SYSTEM_UI_FLAG_FULLSCREEN | SYSTEM_UI_FLAG_HIDE_NAVIGATION);
                String driveApiKey = "AIzaSyDJe_6Ak2OXjN1-pBv9hJYOIU2CyktyKUQ";
                String urls = "https://drive.google.com/file/d/10XYk_iKpdlm1w78GHjDT8lAIhulH_U0G/view?usp=sharing";
                String url = "https://www.googleapis.com/drive/v3/files/" + urls.substring(32, urls.length() - 17) + "?alt=media&key=" + driveApiKey;
                Uri uri = Uri.parse(url);

                mVideoView.setVideoURI(uri);
                mVideoView.start();
            }

        }
    };


    public boolean videoNow(Timestamp time) {
        Timestamp now = Timestamp.now();
        return now.getSeconds() - time.getSeconds() < LATE_TIME && now.getSeconds() - time.getSeconds() > 0;
    }

    public void playVideo(){
        if(!myUrl.equals(NOT_FOUND)) {
            setContentView(R.layout.activity_main);
            VideoView mVideoView = findViewById(R.id.videoview);
            mVideoView.setSystemUiVisibility(SYSTEM_UI_FLAG_FULLSCREEN | SYSTEM_UI_FLAG_HIDE_NAVIGATION);
            String driveApiKey = "AIzaSyDJe_6Ak2OXjN1-pBv9hJYOIU2CyktyKUQ";
            String url = "https://www.googleapis.com/drive/v3/files/" + myUrl.substring(32, myUrl.length() - 17) + "?alt=media&key=" + driveApiKey;
            Uri uri = Uri.parse(url);

            mVideoView.setVideoURI(uri);
            mVideoView.start();
        }
        else{
            openSchedule();
        }
    }

    public void openSchedule(){
        Log.d(TAG, "no video open");
        //TODO this function
    }
}



