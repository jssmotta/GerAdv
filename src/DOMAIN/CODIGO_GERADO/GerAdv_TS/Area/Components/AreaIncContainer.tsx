"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import AreaInc from "../Crud/Inc/Area";
import { getParamFromUrl } from "@/app/tools/helpers";

interface AreaIncContainerProps {
    id: number;
    navigator: INavigator;
}

const AreaIncContainer: React.FC<AreaIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/area"); // 27012025
    const handleError = () => { };

    return (
        <AreaInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default AreaIncContainer;