import React, { useEffect } from "react";
import { Card } from "../../components/card/Card";
import { Wrap } from "../../components/wrap/Wrap";
import { Configuration, UserApi } from "../../services";

export const Profile = () => {
  const getProfileInfo = async () => {
    const config = new Configuration({
      basePath: "http://localhost:5001",
    });

    const userApi = new UserApi(config)
    const result = await userApi.apiUserCurrentGet();

    console.log(result)
  }
  
  useEffect(() => {
    getProfileInfo()
  }, [])
  
  return <Wrap title="Профиль" icon="user">
    <Card title=""></Card>
  </Wrap>;
};
