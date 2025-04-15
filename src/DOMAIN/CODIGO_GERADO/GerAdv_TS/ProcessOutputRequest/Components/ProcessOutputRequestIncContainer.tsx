"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import ProcessOutputRequestInc from "../Crud/Inc/ProcessOutputRequest";
import { getParamFromUrl } from "@/app/tools/helpers";

interface ProcessOutputRequestIncContainerProps {
    id: number;
    navigator: INavigator;
}

const ProcessOutputRequestIncContainer: React.FC<ProcessOutputRequestIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/processoutputrequest"); // 27012025
    const handleError = () => { };

    return (
        <ProcessOutputRequestInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default ProcessOutputRequestIncContainer;