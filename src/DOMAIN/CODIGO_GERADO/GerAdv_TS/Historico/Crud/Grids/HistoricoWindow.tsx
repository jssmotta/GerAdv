import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import HistoricoInc from "../Inc/Historico";
import { IHistorico } from "../../Interfaces/interface.Historico";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { HistoricoEmpty } from "@/app/GerAdv_TS/Models/Historico";
import { useWindow } from "@/app/hooks/useWindows";

interface HistoricoWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedHistorico?: IHistorico;
    onSuccess: () => void;
    onError: () => void;
}

const HistoricoWindow: React.FC<HistoricoWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedHistorico,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/historico/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedHistorico?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedHistorico]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={671}
                    newWidth={1440}
                    id={(selectedHistorico?.id ?? 0).toString()}
                >
                    <HistoricoInc
                        id={selectedHistorico?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowHistorico: React.FC<HistoricoWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <HistoricoWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedHistorico={HistoricoEmpty()}>
        </HistoricoWindow>
    )
};

export default HistoricoWindow;