import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import TipoEMailInc from "../Inc/TipoEMail";
import { ITipoEMail } from "../../Interfaces/interface.TipoEMail";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { TipoEMailEmpty } from "@/app/GerAdv_TS/Models/TipoEMail";
import { useWindow } from "@/app/hooks/useWindows";

interface TipoEMailWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedTipoEMail?: ITipoEMail;
    onSuccess: () => void;
    onError: () => void;
}

const TipoEMailWindow: React.FC<TipoEMailWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedTipoEMail,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/tipoemail/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedTipoEMail?.id}`);
        }

    }, [isMobile, router, selectedTipoEMail]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedTipoEMail?.id ?? 0).toString()}
                >
                    <TipoEMailInc
                        id={selectedTipoEMail?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowTipoEMail: React.FC<TipoEMailWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <TipoEMailWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedTipoEMail={TipoEMailEmpty()}>
        </TipoEMailWindow>
    )
};

export default TipoEMailWindow;