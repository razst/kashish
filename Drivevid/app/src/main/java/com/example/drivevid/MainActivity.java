package com.example.drivevid;


import android.app.Activity;
import android.net.Uri;
import android.os.Bundle;
import android.widget.VideoView;



public class MainActivity extends Activity {


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        VideoView videoView = findViewById(R.id.videoView);

        String driveApiKey = "AIzaSyBBgrjCtCIfgk9XmhWzgKLo_SQTC8_MNRg";
        String shareURL = "https://drive.google.com/file/d/15jzXnAZDTAqw1z_DoNREXmMhFAgjcV2O/view?usp=sharing";
        String url = "https://www.googleapis.com/drive/v3/files/" + shareURL.substring(32, shareURL.length() - 17) + "?alt=media&key="+driveApiKey;
        Uri uri = Uri.parse(url);

        videoView.setVideoURI(uri);
        videoView.start();

       // VideoView videoView = findViewById(R.id.videoView);
      //  MediaController mediaController = new MediaController(this); mediaController.setAnchorView(videoView); videoView.setMediaController(mediaController);



       // videoView.start();




        //https://console.cloud.google.com/apis/
        //https://www.wonderplugin.com/online-tools/google-drive-direct-link-generator/

        //AIzaSyBBgrjCtCIfgk9XmhWzgKLo_SQTC8_MNRg



    }

    }
