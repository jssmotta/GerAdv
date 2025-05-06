import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import StatusBiuInc from "../Inc/StatusBiu";
import { IStatusBiu } from "../../Interfaces/interface.StatusBiu";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { StatusBiuEmpty } from "@/app/GerAdv_TS/Models/StatusBiu";
import { useWindow } from "@/app/hooks/useWindows";

interface StatusBiuWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedStatusBiu?: IStatusBiu;
    onSuccess: () => void;
    onError: () => void;
}

const StatusBiuWindow: React.FC<StatusBiuWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedStatusBiu,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/statusbiu/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedStatusBiu?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedStatusBiu]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedStatusBiu?.id ?? 0).toString()}
                >
                    <StatusBiuInc
                        id={selectedStatusBiu?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowStatusBiu: React.FC<StatusBiuWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <StatusBiuWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedStatusBiu={StatusBiuEmpty()}>
        </StatusBiuWindow>
    )
};

export default StatusBiuWindow;