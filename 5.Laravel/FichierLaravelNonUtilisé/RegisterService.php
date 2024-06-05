<?php

    namespace App\Http\Services;

    use Illuminate\Http\Request;
    use Illuminate\Support\Facades\Validator;
    use Illuminate\Http\Exceptions\HttpResponseException;
    use Illuminate\Support\Facades\Auth;
    use App\Models\User;

    class RegisterService {
        /**
         * Register api
         *
         * @return \Illuminate\Http\Response
         */
        public function register(Request $request)
        {
            try {
                $validator = Validator::make($request->all(), [
                    'name' => 'required',
                    'email' => 'required|email',
                    'password' => 'required',
                    'c_password' => 'required|same:password',
                ]);

                if($validator->fails()){
                    throw new HttpResponseException(
                        response()->json($validator->errors(), 422)
                    );
                }
                $input = $request->all();
                $input['password'] = bcrypt($input['password']);
                $user = User::create($input);
                $success['token'] =  $user->createToken('MyApp')->plainTextToken;
                $success['name'] =  $user->name;

                return $success;

            } catch (\Exception $e) {
                throw ($e);
            }
        }

        /**
         * Login api
         *
         * @return \Illuminate\Http\Response
         */
        public function login(Request $request)
        {
            try {
                if(Auth::attempt(['email' => $request->email, 'password' => $request->password])){
                    $user = Auth::user();
                    $success['token'] =  $user->createToken('MyApp')->plainTextToken;
                    $success['user'] =  $user;

                    return $success;
                }

                throw new HttpResponseException(
                    response()->json(['error'=>'Unauthorised'], 403)
                );

            } catch (\Exception $e) {
                throw ($e);
            }
        }

    }
