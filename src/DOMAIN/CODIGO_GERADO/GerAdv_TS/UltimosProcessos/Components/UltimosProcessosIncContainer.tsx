"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import UltimosProcessosInc from "../Crud/Inc/UltimosProcessos";
import { getParamFromUrl } from "@/app/tools/helpers";

interface UltimosProcessosIncContainerProps {
    id: number;
    navigator: INavigator;
}

const UltimosProcessosIncContainer: React.FC<UltimosProcessosIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/ultimosprocessos"); // 27012025
    const handleError = () => { };

    return (
        <UltimosProcessosInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default UltimosProcessosIncContainer;