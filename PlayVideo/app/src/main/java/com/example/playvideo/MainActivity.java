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

import static android.view.View.SYSTEM_UI_FLAG_FULLSCREEN;
import static android.view.View.SYSTEM_UI_FLAG_HIDE_NAVIGATION;

import com.google.android.gms.auth.api.signin.GoogleSignIn;
import com.google.android.gms.auth.api.signin.GoogleSignInAccount;
import com.google.android.gms.auth.api.signin.GoogleSignInClient;
import com.google.android.gms.auth.api.signin.GoogleSignInOptions;
import com.google.android.gms.common.api.Scope;
import com.google.android.gms.tasks.OnFailureListener;
import com.google.android.gms.tasks.OnSuccessListener;
import com.google.api.client.auth.oauth2.Credential;
import com.google.api.client.extensions.android.http.AndroidHttp;
import com.google.api.client.googleapis.auth.oauth2.GoogleAuthorizationCodeFlow;
import com.google.api.client.googleapis.auth.oauth2.GoogleClientSecrets;
import com.google.api.client.googleapis.extensions.android.gms.auth.GoogleAccountCredential;
import com.google.api.client.http.javanet.NetHttpTransport;
import com.google.api.client.json.JsonFactory;
import com.google.api.client.json.gson.GsonFactory;
import com.google.api.client.json.jackson2.JacksonFactory;
import com.google.api.client.util.store.FileDataStoreFactory;
import com.google.api.services.drive.Drive;
import com.google.api.services.drive.DriveScopes;
import com.google.api.services.drive.model.File;
import com.google.api.services.drive.model.FileList;

import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.Collections;
import java.util.List;

public class MainActivity extends AppCompatActivity {









    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        requestWindowFeature(Window.FEATURE_NO_TITLE);//will hide the title
        getSupportActionBar().hide(); //hide the title bar

        setContentView(R.layout.activity_main);


        Log.d("0","hi");

        requsetSingIn();
        //VideoView mVideoView = findViewById(R.id.videoview);
        //mVideoView.setSystemUiVisibility(SYSTEM_UI_FLAG_FULLSCREEN | SYSTEM_UI_FLAG_HIDE_NAVIGATION);
        //String driveApiKey = "AIzaSyBBgrjCtCIfgk9XmhWzgKLo_SQTC8_MNRg";
        //String shareURL = "https://drive.google.com/file/d/15jzXnAZDTAqw1z_DoNREXmMhFAgjcV2O/view?usp=sharing";
        //String url = "https://www.googleapis.com/drive/v3/files/" + shareURL.substring(32, shareURL.length() - 17) + "?alt=media&key="+driveApiKey;
        //Uri uri = Uri.parse(url);
        //Uri uri = Uri.parse(shareURL);

        //mVideoView.setVideoURI(uri);
        //mVideoView.start();


        // Build a new authorized API client service.



    }

    private void requsetSingIn()
    {
        GoogleSignInOptions signInOptions = new GoogleSignInOptions.Builder(GoogleSignInOptions.DEFAULT_SIGN_IN)
        .requestEmail()
        .requestScopes(new Scope(DriveScopes.DRIVE_FILE))
        .build();


        GoogleSignInClient client =  GoogleSignIn.getClient(this,signInOptions);

        startActivityForResult(client.getSignInIntent(),400);
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, @Nullable Intent data) {
        super.onActivityResult(requestCode, resultCode, data);

        switch (requestCode)
        {
            case 400:
                if(resultCode == RESULT_OK)
                {
                    handleSignInIntent(data);
                }
                break;
        }

    }

    private void handleSignInIntent(Intent data) {

        GoogleSignIn.getSignedInAccountFromIntent(data)
                .addOnSuccessListener(new OnSuccessListener<GoogleSignInAccount>() {
                    @Override
                    public void onSuccess(GoogleSignInAccount googleSignInAccount) {
                        GoogleAccountCredential credential =  GoogleAccountCredential
                                .usingOAuth2(MainActivity.this,Collections.singleton(DriveScopes.DRIVE_FILE));
                        credential.setSelectedAccount(googleSignInAccount.getAccount());

                        try {
                            //HTTP_TRANSPORT = GoogleNetHttpTransport.newTrustedTransport();
                            Drive service = new Drive.Builder(
                                    AndroidHttp.newCompatibleTransport(),
                                    new GsonFactory(),
                                    credential)
                                    .setApplicationName("playvideo")
                                    .build();




                            // Print the names and IDs for up to 10 files.
                            FileList result = service.files().list()
                                    .setPageSize(100)
                                    .setQ("mimeType contains 'text/'")
                                    .setFields("nextPageToken, files(id, name,mimeType,webViewLink,properties)")
                                    .execute();
                            List<File> files = result.getFiles();
                            if (files == null || files.isEmpty()) {
                                System.out.println("No files found.");
                            } else {
                                System.out.println("Files:");
                                for (File file : files) {
                                    Log.d("0",file.getName()+"||" +file.getId()+"||"+ file.getMimeType());
                                }
                            }


                        } catch (IOException e) {
                            e.printStackTrace();
                        }
                    }
                })
                .addOnFailureListener(new OnFailureListener() {
                    @Override
                    public void onFailure(@NonNull Exception e) {

                    }
                });

    }
}

