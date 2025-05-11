import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import AndamentosMDInc from "../Inc/AndamentosMD";
import { IAndamentosMD } from "../../Interfaces/interface.AndamentosMD";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { AndamentosMDEmpty } from "@/app/GerAdv_TS/Models/AndamentosMD";
import { useWindow } from "@/app/hooks/useWindows";

interface AndamentosMDWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedAndamentosMD?: IAndamentosMD;
    onSuccess: () => void;
    onError: () => void;
}

const AndamentosMDWindow: React.FC<AndamentosMDWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedAndamentosMD,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/andamentosmd/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedAndamentosMD?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedAndamentosMD]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedAndamentosMD?.id ?? 0).toString()}
                >
                    <AndamentosMDInc
                        id={selectedAndamentosMD?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowAndamentosMD: React.FC<AndamentosMDWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <AndamentosMDWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedAndamentosMD={AndamentosMDEmpty()}>
        </AndamentosMDWindow>
    )
};

export default AndamentosMDWindow;