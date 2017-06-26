module OAuth2Notes

open System

type OAuthRoles =
    | ResourceOwner
    | ResourceServer
    | Client
    | AuthorizationServer

type GrandType =
    | AuthorizationCode
    | Implicit
    | PasswordCredentials
    | ClientCredentials

type ProtocolFlowEntities = 
    | AuthorizationRequest
    | AuthorizationGrant of GrandType
    | AccessToken
    | ProtectedResource


let protocolflow (fe, r) =
    match fe, r with
    | AuthorizationRequest, ResourceOwner
        -> Some (AuthorizationGrant PasswordCredentials)
    | AuthorizationGrant grandType, AuthorizationServer
        -> Some AccessToken
    | AccessToken, ResourceServer
        -> Some ProtectedResource
    | _ -> None

type AuthorizationServerEndpoints =
    | AuthorizationEndpoint of Uri
    | TokenEndpoint of Uri

type ClientEndpoint = | RedirectionEndpoint of Uri





[<EntryPoint>]
let main argv =
    printfn "%A" argv
    0 // return an integer exit code
