package com.example.playvideo;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.util.Log;
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

import java.net.URL;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.time.Instant;

import static android.view.View.SYSTEM_UI_FLAG_FULLSCREEN;
import static android.view.View.SYSTEM_UI_FLAG_HIDE_NAVIGATION;


public class MainActivity extends AppCompatActivity {

    final String TAG = "fire store data";
    final int LATE_TIME = 900;//time in second that the kashish can late and the video play any way
    final String NOT_FOUND = "not Found";
    private String myUrl = NOT_FOUND;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        requestWindowFeature(Window.FEATURE_NO_TITLE);//will hide the title
        getSupportActionBar().hide(); //hide the title bar
        FirebaseFirestore db = FirebaseFirestore.getInstance();


        Log.d(TAG,  "1" );
        getUrl(db);
        Log.d(TAG,  "2" );



    }

    public void getUrl(FirebaseFirestore db) {
        myUrl = NOT_FOUND;
        db.collection("timetable")
                .get()
                .addOnCompleteListener(new OnCompleteListener<QuerySnapshot>() {
                    @Override
                    public void onComplete(@NonNull Task<QuerySnapshot> task) {
                        if (task.isSuccessful()) {
                            for (QueryDocumentSnapshot document : task.getResult()) {
                                if(videoNow((Timestamp) document.getData().get("startTime"))){
                                    myUrl = (String) document.getData().get("URL");
                                    Log.d(TAG, myUrl);
                                    break;
                                }
                                else {
                                    Log.d(TAG, videoNow((Timestamp) document.getData().get("startTime"))+"");
                                }
                                Log.d(TAG, document.getId() + " => " + document.getData());
                            }
                        } else {
                            Log.w(TAG, "Error getting documents.", task.getException());
                        }
                        playVideo();
                    }
                });
    }

    public boolean videoNow(Timestamp time) {
        Timestamp now = Timestamp.now();
        if(now.getSeconds() - time.getSeconds() < LATE_TIME && now.getSeconds() - time.getSeconds() > 0){
            return true;
        }
        else {
            return false;
        }
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

