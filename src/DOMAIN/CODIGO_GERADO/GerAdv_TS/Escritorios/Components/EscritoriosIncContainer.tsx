"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import EscritoriosInc from "../Crud/Inc/Escritorios";
import { getParamFromUrl } from "@/app/tools/helpers";

interface EscritoriosIncContainerProps {
    id: number;
    navigator: INavigator;
}

const EscritoriosIncContainer: React.FC<EscritoriosIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/escritorios"); // 27012025
    const handleError = () => { };

    return (
        <EscritoriosInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default EscritoriosIncContainer;