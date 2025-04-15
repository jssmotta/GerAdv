"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import PosicaoOutrasPartesInc from "../Crud/Inc/PosicaoOutrasPartes";
import { getParamFromUrl } from "@/app/tools/helpers";

interface PosicaoOutrasPartesIncContainerProps {
    id: number;
    navigator: INavigator;
}

const PosicaoOutrasPartesIncContainer: React.FC<PosicaoOutrasPartesIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/posicaooutraspartes"); // 27012025
    const handleError = () => { };

    return (
        <PosicaoOutrasPartesInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default PosicaoOutrasPartesIncContainer;