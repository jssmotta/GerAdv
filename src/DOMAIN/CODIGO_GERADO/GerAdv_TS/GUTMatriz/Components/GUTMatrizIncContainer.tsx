"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import GUTMatrizInc from "../Crud/Inc/GUTMatriz";
import { getParamFromUrl } from "@/app/tools/helpers";

interface GUTMatrizIncContainerProps {
    id: number;
    navigator: INavigator;
}

const GUTMatrizIncContainer: React.FC<GUTMatrizIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/gutmatriz"); // 27012025
    const handleError = () => { };

    return (
        <GUTMatrizInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default GUTMatrizIncContainer;