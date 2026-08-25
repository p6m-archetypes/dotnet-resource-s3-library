-- dotnet-resource-s3-library main module.
-- Renders AWSSDK.S3 service extension into the service project Resources/ folder.
--
-- The calling archetype is responsible for adding AWSSDK.S3 to the .csproj.
--
-- API:
--   local s3 = require("dotnet-resource-s3")
--   s3.render(context, { destination = context:get("project-name") })

local M = {}

function M.render(context, opts)
    opts = opts or {}
    local d = opts.destination
    if d and d ~= "" then
        directory.render("contents", context, { destination = d })
    else
        directory.render("contents", context)
    end
    return context
end

return M
