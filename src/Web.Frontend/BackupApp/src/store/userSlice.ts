import { createSlice, PayloadAction } from "@reduxjs/toolkit";

export type TUserName = {
  firstName: string;
  lastName?: string;
  middleName?: string;
};

export type TUser = {
  id: number;
  name: TUserName;
  email: string;
  phone: string;
  birthDate?: string;
};

export interface IUserSlice {
  user?: TUser;
  logged?: boolean;
}

const initialState: IUserSlice = {};

export const userSlice = createSlice({
  name: "user",
  initialState,
  reducers: {
    setUser: (state, action: PayloadAction<IUserSlice>) => {
      // ...
    },
  },
});

export const { setUser } = userSlice.actions;

export default userSlice.reducer;
