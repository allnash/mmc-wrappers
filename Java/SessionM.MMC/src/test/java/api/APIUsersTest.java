package api;

import com.sessionm.api.factory.UserFactory;
import com.sessionm.models.User;
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


public class APIUsersTest {

    @BeforeClass
    public static void setup() {

    }

    @AfterClass
    public static void teardown() {

    }

    @Test
    public void testCreateUser() throws Exception {
      String uuid = UUID.randomUUID().toString();
      Date date = new Date();
      SimpleDateFormat sdf = new SimpleDateFormat("yyyy-mm-dd");
      String dateInString = "1982-08-31";
      User u = UserFactory.createUser(uuid,"test" + TestUtility.generateRandomString() + "@example.com", UserFactory.UserGender.f,sdf.parse(dateInString),"1.1.1.1").get();
      Assert.assertNotNull(u);
      Assert.assertTrue(uuid.equals(u.getExternalId()));
      System.out.println("User created - " + u.getExternalId());
      System.out.println("User email - " + u.getEmail());

    }

    @Test
    public void testFetchUser() throws Exception {
        String uuid = UUID.randomUUID().toString();
        Date date = new Date();
        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-mm-dd");
        String dateInString = "1982-08-31";
        User u = UserFactory.createUser(uuid,"test" + TestUtility.generateRandomString() + "@example.com", UserFactory.UserGender.f,sdf.parse(dateInString),"1.1.1.1").get();
        Assert.assertNotNull(u);
        Assert.assertTrue(uuid.equals(u.getExternalId()));
        System.out.println("User created - " + u.getExternalId());
        System.out.println("User email - " + u.getEmail());
        User fu = UserFactory.fetchUserWithId(u.getId()).get();
        Assert.assertNotNull(fu);
        User fue = UserFactory.fetchUserWithExternalId(u.getExternalId()).get();
        Assert.assertNotNull(fue);
    }


    @Test
    public void testUserUpdate() throws Exception {
        String uuid = UUID.randomUUID().toString();
        Date date = new Date();
        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-mm-dd");
        String dateInString = "1982-08-31";
        User u = UserFactory.createUser(uuid,"test" + TestUtility.generateRandomString() + "@example.com", UserFactory.UserGender.f,sdf.parse(dateInString),"1.1.1.1").get();
        Assert.assertNotNull(u);
        Assert.assertTrue(uuid.equals(u.getExternalId()));
        System.out.println("User created - " + u.getExternalId());
        System.out.println("User email - " + u.getEmail());

    }
}
