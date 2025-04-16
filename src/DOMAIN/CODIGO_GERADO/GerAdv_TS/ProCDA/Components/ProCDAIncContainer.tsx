"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import ProCDAInc from "../Crud/Inc/ProCDA";
import { getParamFromUrl } from "@/app/tools/helpers";

interface ProCDAIncContainerProps {
    id: number;
    navigator: INavigator;
}

const ProCDAIncContainer: React.FC<ProCDAIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/procda"); // 27012025
    const handleError = () => { };

    return (
        <ProCDAInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default ProCDAIncContainer;