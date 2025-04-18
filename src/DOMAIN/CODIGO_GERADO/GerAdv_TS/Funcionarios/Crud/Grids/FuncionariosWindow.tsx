﻿import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import FuncionariosInc from "../Inc/Funcionarios";
import { IFuncionarios } from "../../Interfaces/interface.Funcionarios";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { FuncionariosEmpty } from "@/app/GerAdv_TS/Models/Funcionarios";
import { useWindow } from "@/app/hooks/useWindows";

interface FuncionariosWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedFuncionarios?: IFuncionarios;
    onSuccess: () => void;
    onError: () => void;
}

const FuncionariosWindow: React.FC<FuncionariosWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedFuncionarios,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/funcionarios/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedFuncionarios?.id}`);
        }

    }, [isMobile, router, selectedFuncionarios]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={905}
                    newWidth={1440}
                    id={(selectedFuncionarios?.id ?? 0).toString()}
                >
                    <FuncionariosInc
                        id={selectedFuncionarios?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowFuncionarios: React.FC<FuncionariosWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <FuncionariosWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedFuncionarios={FuncionariosEmpty()}>
        </FuncionariosWindow>
    )
};

export default FuncionariosWindow;