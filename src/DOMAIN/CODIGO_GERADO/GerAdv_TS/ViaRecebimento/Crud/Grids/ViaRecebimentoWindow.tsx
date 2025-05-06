import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import ViaRecebimentoInc from "../Inc/ViaRecebimento";
import { IViaRecebimento } from "../../Interfaces/interface.ViaRecebimento";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { ViaRecebimentoEmpty } from "@/app/GerAdv_TS/Models/ViaRecebimento";
import { useWindow } from "@/app/hooks/useWindows";

interface ViaRecebimentoWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedViaRecebimento?: IViaRecebimento;
    onSuccess: () => void;
    onError: () => void;
}

const ViaRecebimentoWindow: React.FC<ViaRecebimentoWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedViaRecebimento,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/viarecebimento/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedViaRecebimento?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedViaRecebimento]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedViaRecebimento?.id ?? 0).toString()}
                >
                    <ViaRecebimentoInc
                        id={selectedViaRecebimento?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowViaRecebimento: React.FC<ViaRecebimentoWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <ViaRecebimentoWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedViaRecebimento={ViaRecebimentoEmpty()}>
        </ViaRecebimentoWindow>
    )
};

export default ViaRecebimentoWindow;