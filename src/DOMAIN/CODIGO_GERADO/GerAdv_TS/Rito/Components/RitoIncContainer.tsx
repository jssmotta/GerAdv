"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import RitoInc from "../Crud/Inc/Rito";
import { getParamFromUrl } from "@/app/tools/helpers";

interface RitoIncContainerProps {
    id: number;
    navigator: INavigator;
}

const RitoIncContainer: React.FC<RitoIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/rito"); // 27012025
    const handleError = () => { };

    return (
        <RitoInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default RitoIncContainer;