import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import StatusHTrabInc from "../Inc/StatusHTrab";
import { IStatusHTrab } from "../../Interfaces/interface.StatusHTrab";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { StatusHTrabEmpty } from "@/app/GerAdv_TS/Models/StatusHTrab";
import { useWindow } from "@/app/hooks/useWindows";

interface StatusHTrabWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedStatusHTrab?: IStatusHTrab;
    onSuccess: () => void;
    onError: () => void;
}

const StatusHTrabWindow: React.FC<StatusHTrabWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedStatusHTrab,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/statushtrab/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedStatusHTrab?.id}`);
        }

    }, [isMobile, router, selectedStatusHTrab]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedStatusHTrab?.id ?? 0).toString()}
                >
                    <StatusHTrabInc
                        id={selectedStatusHTrab?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowStatusHTrab: React.FC<StatusHTrabWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <StatusHTrabWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedStatusHTrab={StatusHTrabEmpty()}>
        </StatusHTrabWindow>
    )
};

export default StatusHTrabWindow;