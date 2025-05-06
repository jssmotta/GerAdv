import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import AnexamentoRegistrosInc from "../Inc/AnexamentoRegistros";
import { IAnexamentoRegistros } from "../../Interfaces/interface.AnexamentoRegistros";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { AnexamentoRegistrosEmpty } from "@/app/GerAdv_TS/Models/AnexamentoRegistros";
import { useWindow } from "@/app/hooks/useWindows";

interface AnexamentoRegistrosWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedAnexamentoRegistros?: IAnexamentoRegistros;
    onSuccess: () => void;
    onError: () => void;
}

const AnexamentoRegistrosWindow: React.FC<AnexamentoRegistrosWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedAnexamentoRegistros,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/anexamentoregistros/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedAnexamentoRegistros?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedAnexamentoRegistros]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={633}
                    newWidth={720}
                    id={(selectedAnexamentoRegistros?.id ?? 0).toString()}
                >
                    <AnexamentoRegistrosInc
                        id={selectedAnexamentoRegistros?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowAnexamentoRegistros: React.FC<AnexamentoRegistrosWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <AnexamentoRegistrosWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedAnexamentoRegistros={AnexamentoRegistrosEmpty()}>
        </AnexamentoRegistrosWindow>
    )
};

export default AnexamentoRegistrosWindow;