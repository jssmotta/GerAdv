"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import TerceirosInc from "../Crud/Inc/Terceiros";
import { getParamFromUrl } from "@/app/tools/helpers";

interface TerceirosIncContainerProps {
    id: number;
    navigator: INavigator;
}

const TerceirosIncContainer: React.FC<TerceirosIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/terceiros"); // 27012025
    const handleError = () => { };

    return (
        <TerceirosInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default TerceirosIncContainer;