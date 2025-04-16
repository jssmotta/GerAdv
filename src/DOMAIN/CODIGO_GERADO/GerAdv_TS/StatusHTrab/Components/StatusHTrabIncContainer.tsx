"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import StatusHTrabInc from "../Crud/Inc/StatusHTrab";
import { getParamFromUrl } from "@/app/tools/helpers";

interface StatusHTrabIncContainerProps {
    id: number;
    navigator: INavigator;
}

const StatusHTrabIncContainer: React.FC<StatusHTrabIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/statushtrab"); // 27012025
    const handleError = () => { };

    return (
        <StatusHTrabInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default StatusHTrabIncContainer;