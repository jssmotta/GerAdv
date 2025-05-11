import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import ProObservacoesInc from "../Inc/ProObservacoes";
import { IProObservacoes } from "../../Interfaces/interface.ProObservacoes";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { ProObservacoesEmpty } from "@/app/GerAdv_TS/Models/ProObservacoes";
import { useWindow } from "@/app/hooks/useWindows";

interface ProObservacoesWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedProObservacoes?: IProObservacoes;
    onSuccess: () => void;
    onError: () => void;
}

const ProObservacoesWindow: React.FC<ProObservacoesWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedProObservacoes,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/proobservacoes/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedProObservacoes?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedProObservacoes]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedProObservacoes?.id ?? 0).toString()}
                >
                    <ProObservacoesInc
                        id={selectedProObservacoes?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowProObservacoes: React.FC<ProObservacoesWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <ProObservacoesWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedProObservacoes={ProObservacoesEmpty()}>
        </ProObservacoesWindow>
    )
};

export default ProObservacoesWindow;