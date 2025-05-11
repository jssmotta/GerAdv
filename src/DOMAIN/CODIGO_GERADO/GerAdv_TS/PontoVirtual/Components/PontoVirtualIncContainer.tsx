"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import PontoVirtualInc from "../Crud/Inc/PontoVirtual";
import { getParamFromUrl } from "@/app/tools/helpers";

interface PontoVirtualIncContainerProps {
    id: number;
    navigator: INavigator;
}

const PontoVirtualIncContainer: React.FC<PontoVirtualIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/pontovirtual"); // 27012025
    const handleError = () => { };

    return (
        <PontoVirtualInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default PontoVirtualIncContainer;