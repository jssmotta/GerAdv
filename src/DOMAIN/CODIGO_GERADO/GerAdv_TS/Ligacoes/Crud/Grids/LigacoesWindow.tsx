import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import LigacoesInc from "../Inc/Ligacoes";
import { ILigacoes } from "../../Interfaces/interface.Ligacoes";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { LigacoesEmpty } from "@/app/GerAdv_TS/Models/Ligacoes";
import { useWindow } from "@/app/hooks/useWindows";

interface LigacoesWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedLigacoes?: ILigacoes;
    onSuccess: () => void;
    onError: () => void;
}

const LigacoesWindow: React.FC<LigacoesWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedLigacoes,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/ligacoes/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedLigacoes?.id}`);
        }

    }, [isMobile, router, selectedLigacoes]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={845}
                    newWidth={1440}
                    id={(selectedLigacoes?.id ?? 0).toString()}
                >
                    <LigacoesInc
                        id={selectedLigacoes?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowLigacoes: React.FC<LigacoesWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <LigacoesWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedLigacoes={LigacoesEmpty()}>
        </LigacoesWindow>
    )
};

export default LigacoesWindow;