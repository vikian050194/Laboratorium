let decart a b = a |> List.map (fun x -> b |> List.map (fun y -> (x,y))) |> List.concat