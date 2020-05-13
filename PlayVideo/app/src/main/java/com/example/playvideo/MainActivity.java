package com.example.playvideo;

import androidx.appcompat.app.AppCompatActivity;

import android.net.Uri;
import android.os.Bundle;
import android.view.View;
import android.view.Window;
import android.widget.VideoView;

import static android.view.View.SYSTEM_UI_FLAG_FULLSCREEN;
import static android.view.View.SYSTEM_UI_FLAG_HIDE_NAVIGATION;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        requestWindowFeature(Window.FEATURE_NO_TITLE);//will hide the title
        getSupportActionBar().hide(); //hide the title bar

        setContentView(R.layout.activity_main);

        VideoView mVideoView = findViewById(R.id.videoview);
        mVideoView.setSystemUiVisibility(SYSTEM_UI_FLAG_FULLSCREEN | SYSTEM_UI_FLAG_HIDE_NAVIGATION);
        String driveApiKey = "AIzaSyBBgrjCtCIfgk9XmhWzgKLo_SQTC8_MNRg";
        String shareURL = "https://drive.google.com/file/d/15jzXnAZDTAqw1z_DoNREXmMhFAgjcV2O/view?usp=sharing";
        String url = "https://www.googleapis.com/drive/v3/files/" + shareURL.substring(32, shareURL.length() - 17) + "?alt=media&key="+driveApiKey;
        Uri uri = Uri.parse(url);
        //Uri uri = Uri.parse(shareURL);

        mVideoView.setVideoURI(uri);
        mVideoView.start();
    }
}
