﻿"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import AreasJusticaInc from "../Crud/Inc/AreasJustica";
import { getParamFromUrl } from "@/app/tools/helpers";

interface AreasJusticaIncContainerProps {
    id: number;
    navigator: INavigator;
}

const AreasJusticaIncContainer: React.FC<AreasJusticaIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/areasjustica"); // 27012025
    const handleError = () => { };

    return (
        <AreasJusticaInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default AreasJusticaIncContainer;