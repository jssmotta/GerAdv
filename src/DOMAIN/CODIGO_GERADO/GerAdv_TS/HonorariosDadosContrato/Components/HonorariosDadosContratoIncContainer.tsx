"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import HonorariosDadosContratoInc from "../Crud/Inc/HonorariosDadosContrato";
import { getParamFromUrl } from "@/app/tools/helpers";

interface HonorariosDadosContratoIncContainerProps {
    id: number;
    navigator: INavigator;
}

const HonorariosDadosContratoIncContainer: React.FC<HonorariosDadosContratoIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/honorariosdadoscontrato"); // 27012025
    const handleError = () => { };

    return (
        <HonorariosDadosContratoInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default HonorariosDadosContratoIncContainer;