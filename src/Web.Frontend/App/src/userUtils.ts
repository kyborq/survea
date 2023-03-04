import { Configuration, UserApi } from "./services";

export const getCurrentUser = async () => {
  const config = new Configuration({
    basePath: "http://localhost:5001",
  });

  const attemptApi = new UserApi(config);

  const result = await attemptApi.apiUserCurrentGet({
    withCredentials: true,
  });

  return result.data;
};
