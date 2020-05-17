package com.example.playvideo;

import androidx.appcompat.app.AppCompatActivity;

import android.net.Uri;
import android.os.Bundle;
import android.view.Window;
import android.widget.VideoView;

import static android.view.View.SYSTEM_UI_FLAG_FULLSCREEN;
import static android.view.View.SYSTEM_UI_FLAG_HIDE_NAVIGATION;

import com.google.api.client.auth.oauth2.Credential;
import com.google.api.client.extensions.java6.auth.oauth2.AuthorizationCodeInstalledApp;
import com.google.api.client.extensions.jetty.auth.oauth2.LocalServerReceiver;
import com.google.api.client.googleapis.auth.oauth2.GoogleAuthorizationCodeFlow;
import com.google.api.client.googleapis.auth.oauth2.GoogleClientSecrets;
import com.google.api.client.http.javanet.NetHttpTransport;
import com.google.api.client.json.JsonFactory;
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

    private static final String APPLICATION_NAME = "Google Drive API Java Quickstart";
    private static final JsonFactory JSON_FACTORY = JacksonFactory.getDefaultInstance();
    private static final String TOKENS_DIRECTORY_PATH = "tokens";
    /**
     * Global instance of the scopes required by this quickstart.
     * If modifying these scopes, delete your previously saved tokens/ folder.
     */
    private static final List<String> SCOPES = Collections.singletonList(DriveScopes.DRIVE_METADATA_READONLY);
    private static final String CREDENTIALS_FILE_PATH = "/credentials_android.json";


    /**
     * Creates an authorized Credential object.
     * @param HTTP_TRANSPORT The network HTTP Transport.
     * @return An authorized Credential object.
     * @throws IOException If the credentials.json file cannot be found.
     */
    private Credential getCredentials(final NetHttpTransport HTTP_TRANSPORT) throws IOException {
        // Load client secrets.
        //InputStream in = MainActivity.class.getResourceAsStream(CREDENTIALS_FILE_PATH);
        InputStream in = getResources().openRawResource(R.raw.credentials_android);
        if (in == null) {
            throw new FileNotFoundException("Resource not found: " + CREDENTIALS_FILE_PATH);
        }
        GoogleClientSecrets clientSecrets = GoogleClientSecrets.load(JSON_FACTORY, new InputStreamReader(in));

        // Build flow and trigger user authorization request.
        GoogleAuthorizationCodeFlow flow = new GoogleAuthorizationCodeFlow.Builder(
                HTTP_TRANSPORT, JSON_FACTORY, clientSecrets, SCOPES)
                //.setDataStoreFactory(new FileDataStoreFactory(new java.io.File(TOKENS_DIRECTORY_PATH)))
                .setAccessType("offline")
                .build();
        LocalServerReceiver receiver = new LocalServerReceiver.Builder().setPort(8888).build();
        return new AuthorizationCodeInstalledApp(flow, receiver).authorize("user");
    }



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
        //Uri uri = Uri.parse(url);
        Uri uri = Uri.parse("https://www.drivehq.com/file/DFPublishFile.aspx/FileID7155480515/Keyovdybccfaog2/WIN_20200515_16_24_36_Pro.mp4");
                            // https://www.drivehq.com/file/DFPublishFile.aspx/FileID7155513124/Keyu0gbwenen86n/Camera3_18-16-08.mp4
        mVideoView.setVideoURI(uri);
        mVideoView.start();

/*
        // Build a new authorized API client service.
        final NetHttpTransport HTTP_TRANSPORT;
        try {
            //HTTP_TRANSPORT = GoogleNetHttpTransport.newTrustedTransport();
            HTTP_TRANSPORT = new com.google.api.client.http.javanet.NetHttpTransport();
            Drive service = new Drive.Builder(HTTP_TRANSPORT, JSON_FACTORY, getCredentials(HTTP_TRANSPORT))
                    .setApplicationName(APPLICATION_NAME)
                    .build();


            // Print the names and IDs for up to 10 files.
            FileList result = service.files().list()
                    .setPageSize(100)
                    .setQ("mimeType contains 'image/'")
                    .setFields("nextPageToken, files(id, name,mimeType,webViewLink,properties)")
                    .execute();
            List<File> files = result.getFiles();
            if (files == null || files.isEmpty()) {
                System.out.println("No files found.");
            } else {
                System.out.println("Files:");
                for (File file : files) {
                    System.out.printf("%s | %s | %s | %s \n", file.getName(), file.getId(),file.getMimeType(), 	file.getWebViewLink());
                }
            }


        } catch (IOException e) {
            e.printStackTrace();
        }*/


    }
}
