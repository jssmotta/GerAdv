import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import AreaInc from "../Inc/Area";
import { IArea } from "../../Interfaces/interface.Area";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { AreaEmpty } from "@/app/GerAdv_TS/Models/Area";
import { useWindow } from "@/app/hooks/useWindows";

interface AreaWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedArea?: IArea;
    onSuccess: () => void;
    onError: () => void;
}

const AreaWindow: React.FC<AreaWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedArea,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/area/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedArea?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedArea]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedArea?.id ?? 0).toString()}
                >
                    <AreaInc
                        id={selectedArea?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowArea: React.FC<AreaWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <AreaWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedArea={AreaEmpty()}>
        </AreaWindow>
    )
};

export default AreaWindow;