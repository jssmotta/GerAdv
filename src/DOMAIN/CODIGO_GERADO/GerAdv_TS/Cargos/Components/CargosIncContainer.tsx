"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import CargosInc from "../Crud/Inc/Cargos";
import { getParamFromUrl } from "@/app/tools/helpers";

interface CargosIncContainerProps {
    id: number;
    navigator: INavigator;
}

const CargosIncContainer: React.FC<CargosIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/cargos"); // 27012025
    const handleError = () => { };

    return (
        <CargosInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default CargosIncContainer;