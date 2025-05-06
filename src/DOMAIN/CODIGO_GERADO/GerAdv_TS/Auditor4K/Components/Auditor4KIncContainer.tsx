"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import Auditor4KInc from "../Crud/Inc/Auditor4K";
import { getParamFromUrl } from "@/app/tools/helpers";

interface Auditor4KIncContainerProps {
    id: number;
    navigator: INavigator;
}

const Auditor4KIncContainer: React.FC<Auditor4KIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/auditor4k"); // 27012025
    const handleError = () => { };

    return (
        <Auditor4KInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default Auditor4KIncContainer;