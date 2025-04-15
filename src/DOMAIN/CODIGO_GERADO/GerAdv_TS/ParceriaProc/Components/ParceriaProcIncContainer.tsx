"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import ParceriaProcInc from "../Crud/Inc/ParceriaProc";
import { getParamFromUrl } from "@/app/tools/helpers";

interface ParceriaProcIncContainerProps {
    id: number;
    navigator: INavigator;
}

const ParceriaProcIncContainer: React.FC<ParceriaProcIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/parceriaproc"); // 27012025
    const handleError = () => { };

    return (
        <ParceriaProcInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default ParceriaProcIncContainer;