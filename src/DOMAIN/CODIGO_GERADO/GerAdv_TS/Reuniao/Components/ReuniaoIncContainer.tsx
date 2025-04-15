"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import ReuniaoInc from "../Crud/Inc/Reuniao";
import { getParamFromUrl } from "@/app/tools/helpers";

interface ReuniaoIncContainerProps {
    id: number;
    navigator: INavigator;
}

const ReuniaoIncContainer: React.FC<ReuniaoIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/reuniao"); // 27012025
    const handleError = () => { };

    return (
        <ReuniaoInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default ReuniaoIncContainer;