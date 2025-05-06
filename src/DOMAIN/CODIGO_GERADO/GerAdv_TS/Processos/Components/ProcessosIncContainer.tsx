"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import ProcessosInc from "../Crud/Inc/Processos";
import { getParamFromUrl } from "@/app/tools/helpers";

interface ProcessosIncContainerProps {
    id: number;
    navigator: INavigator;
}

const ProcessosIncContainer: React.FC<ProcessosIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/processos"); // 27012025
    const handleError = () => { };

    return (
        <ProcessosInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default ProcessosIncContainer;