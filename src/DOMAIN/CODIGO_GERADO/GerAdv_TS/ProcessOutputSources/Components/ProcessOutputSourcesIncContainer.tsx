"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import ProcessOutputSourcesInc from "../Crud/Inc/ProcessOutputSources";
import { getParamFromUrl } from "@/app/tools/helpers";

interface ProcessOutputSourcesIncContainerProps {
    id: number;
    navigator: INavigator;
}

const ProcessOutputSourcesIncContainer: React.FC<ProcessOutputSourcesIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/processoutputsources"); // 27012025
    const handleError = () => { };

    return (
        <ProcessOutputSourcesInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default ProcessOutputSourcesIncContainer;