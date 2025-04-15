"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import CargosEscInc from "../Crud/Inc/CargosEsc";
import { getParamFromUrl } from "@/app/tools/helpers";

interface CargosEscIncContainerProps {
    id: number;
    navigator: INavigator;
}

const CargosEscIncContainer: React.FC<CargosEscIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/cargosesc"); // 27012025
    const handleError = () => { };

    return (
        <CargosEscInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default CargosEscIncContainer;