"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import GUTPeriodicidadeStatusInc from "../Crud/Inc/GUTPeriodicidadeStatus";
import { getParamFromUrl } from "@/app/tools/helpers";

interface GUTPeriodicidadeStatusIncContainerProps {
    id: number;
    navigator: INavigator;
}

const GUTPeriodicidadeStatusIncContainer: React.FC<GUTPeriodicidadeStatusIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/gutperiodicidadestatus"); // 27012025
    const handleError = () => { };

    return (
        <GUTPeriodicidadeStatusInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default GUTPeriodicidadeStatusIncContainer;