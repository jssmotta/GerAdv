﻿import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import LivroCaixaInc from "../Inc/LivroCaixa";
import { ILivroCaixa } from "../../Interfaces/interface.LivroCaixa";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { LivroCaixaEmpty } from "@/app/GerAdv_TS/Models/LivroCaixa";
import { useWindow } from "@/app/hooks/useWindows";

interface LivroCaixaWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedLivroCaixa?: ILivroCaixa;
    onSuccess: () => void;
    onError: () => void;
}

const LivroCaixaWindow: React.FC<LivroCaixaWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedLivroCaixa,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/livrocaixa/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedLivroCaixa?.id}`);
        }

    }, [isMobile, router, selectedLivroCaixa]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={585}
                    newWidth={1440}
                    id={(selectedLivroCaixa?.id ?? 0).toString()}
                >
                    <LivroCaixaInc
                        id={selectedLivroCaixa?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowLivroCaixa: React.FC<LivroCaixaWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <LivroCaixaWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedLivroCaixa={LivroCaixaEmpty()}>
        </LivroCaixaWindow>
    )
};

export default LivroCaixaWindow;