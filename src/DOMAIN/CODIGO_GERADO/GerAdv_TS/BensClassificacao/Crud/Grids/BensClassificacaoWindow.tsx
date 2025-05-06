import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import BensClassificacaoInc from "../Inc/BensClassificacao";
import { IBensClassificacao } from "../../Interfaces/interface.BensClassificacao";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { BensClassificacaoEmpty } from "@/app/GerAdv_TS/Models/BensClassificacao";
import { useWindow } from "@/app/hooks/useWindows";

interface BensClassificacaoWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedBensClassificacao?: IBensClassificacao;
    onSuccess: () => void;
    onError: () => void;
}

const BensClassificacaoWindow: React.FC<BensClassificacaoWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedBensClassificacao,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/bensclassificacao/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedBensClassificacao?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedBensClassificacao]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedBensClassificacao?.id ?? 0).toString()}
                >
                    <BensClassificacaoInc
                        id={selectedBensClassificacao?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowBensClassificacao: React.FC<BensClassificacaoWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <BensClassificacaoWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedBensClassificacao={BensClassificacaoEmpty()}>
        </BensClassificacaoWindow>
    )
};

export default BensClassificacaoWindow;