import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { Button } from "../../components/button/Button";
import { Card } from "../../components/card/Card";
import { Wrap } from "../../components/wrap/Wrap";
import { Configuration, LoginApi, UserApi } from "../../services";

type TProfile = {
  name: string;
  email: string;
};

export const Profile = () => {
  const [user, setUser] = useState<TProfile>();
  const navigate = useNavigate();

  const getProfileInfo = async () => {
    const config = new Configuration({
      basePath: "http://localhost:5001",
    });

    const userApi = new UserApi(config);
    const result = await userApi.apiUserCurrentGet({
      withCredentials: true,
    });

    if (result.status === 200) {
      setUser({
        name: result.data.name,
        email: result.data.email,
      });
    }
  };

  useEffect(() => {
    getProfileInfo();
  }, []);

  return (
    <Wrap title="Профиль" icon="user">
      <Card>
        {!!user && (
          <div
            style={{
              width: 128,
              height: 128,
              borderRadius: "100%",
              justifyContent: "center",
              alignItems: "center",
              display: "flex",
              backgroundColor: "#f2f2f2",
            }}
          >
            <h2>{`${user.name
              .split(" ")
              .map((w) => w[0])
              .join("")}`}</h2>
          </div>
        )}

        {!!user && (
          <div>
            <h2>{user.name}</h2>
            <h3>{user.email}</h3>
          </div>
        )}

        {!!user && (
          <Button
            label="Выйти"
            onClick={async () => {
              const config = new Configuration({
                basePath: "http://localhost:5001",
              });

              const userApi = new LoginApi(config);
              const result = await userApi.apiLoginLogoutPost({
                withCredentials: true,
              });

              if (result.status === 200) {
                navigate("/login");
              }
            }}
          />
        )}
      </Card>
    </Wrap>
  );
};
