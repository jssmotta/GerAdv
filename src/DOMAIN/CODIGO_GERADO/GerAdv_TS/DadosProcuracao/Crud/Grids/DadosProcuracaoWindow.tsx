import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import DadosProcuracaoInc from "../Inc/DadosProcuracao";
import { IDadosProcuracao } from "../../Interfaces/interface.DadosProcuracao";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { DadosProcuracaoEmpty } from "@/app/GerAdv_TS/Models/DadosProcuracao";
import { useWindow } from "@/app/hooks/useWindows";

interface DadosProcuracaoWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedDadosProcuracao?: IDadosProcuracao;
    onSuccess: () => void;
    onError: () => void;
}

const DadosProcuracaoWindow: React.FC<DadosProcuracaoWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedDadosProcuracao,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/dadosprocuracao/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedDadosProcuracao?.id}`);
        }

    }, [isMobile, router, selectedDadosProcuracao]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={791}
                    newWidth={720}
                    id={(selectedDadosProcuracao?.id ?? 0).toString()}
                >
                    <DadosProcuracaoInc
                        id={selectedDadosProcuracao?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowDadosProcuracao: React.FC<DadosProcuracaoWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <DadosProcuracaoWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedDadosProcuracao={DadosProcuracaoEmpty()}>
        </DadosProcuracaoWindow>
    )
};

export default DadosProcuracaoWindow;