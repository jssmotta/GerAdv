import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import ProCDAInc from "../Inc/ProCDA";
import { IProCDA } from "../../Interfaces/interface.ProCDA";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { ProCDAEmpty } from "@/app/GerAdv_TS/Models/ProCDA";
import { useWindow } from "@/app/hooks/useWindows";

interface ProCDAWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedProCDA?: IProCDA;
    onSuccess: () => void;
    onError: () => void;
}

const ProCDAWindow: React.FC<ProCDAWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedProCDA,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/procda/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedProCDA?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedProCDA]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedProCDA?.id ?? 0).toString()}
                >
                    <ProCDAInc
                        id={selectedProCDA?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowProCDA: React.FC<ProCDAWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <ProCDAWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedProCDA={ProCDAEmpty()}>
        </ProCDAWindow>
    )
};

export default ProCDAWindow;