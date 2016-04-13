package api;

import com.fasterxml.jackson.databind.JsonNode;
import com.sessionm.api.factory.ContentFactory;
import com.sessionm.api.factory.UserFactory;
import com.sessionm.models.Content;
import org.junit.AfterClass;
import org.junit.Assert;
import org.junit.BeforeClass;
import org.junit.Test;
import scala.concurrent.duration.Duration;
import scala.concurrent.duration.FiniteDuration;
import utils.TestUtility;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.UUID;


public class ContentsTest {

    @BeforeClass
    public static void setup() {

    }

    @AfterClass
    public static void teardown() {

    }

    static FiniteDuration workTimeout = Duration.create(3, "seconds");
    static FiniteDuration registerInterval = Duration.create(1, "second");

    @Test
    public void testCreateContent() throws Exception {

        String externalContentId = UUID.randomUUID().toString();
        Content c = ContentFactory.createContent(externalContentId,
                                                "Test Content",
                                                "This is a description",
                                                "home_feed",
                                                null,
                                                "https://ww.example.com",
                                                null,
                                                null,
                                                null,
                                                null,
                                                1).get();
        Assert.assertNotNull(c);
        Assert.assertTrue(externalContentId.equals(c.getExternalId()));
        System.out.println("Content created - " + c.getExternalId());
        System.out.println("Content created_at - " + c.getCreatedAt());

    }


    @Test
    public void testUpdateContent() throws Exception {

    }
}
