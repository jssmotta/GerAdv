import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import SituacaoInc from "../Inc/Situacao";
import { ISituacao } from "../../Interfaces/interface.Situacao";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { SituacaoEmpty } from "@/app/GerAdv_TS/Models/Situacao";
import { useWindow } from "@/app/hooks/useWindows";

interface SituacaoWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedSituacao?: ISituacao;
    onSuccess: () => void;
    onError: () => void;
}

const SituacaoWindow: React.FC<SituacaoWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedSituacao,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/situacao/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedSituacao?.id}`);
        }

    }, [isMobile, router, selectedSituacao]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedSituacao?.id ?? 0).toString()}
                >
                    <SituacaoInc
                        id={selectedSituacao?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowSituacao: React.FC<SituacaoWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <SituacaoWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedSituacao={SituacaoEmpty()}>
        </SituacaoWindow>
    )
};

export default SituacaoWindow;