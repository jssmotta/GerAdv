import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import EndTitInc from "../Inc/EndTit";
import { IEndTit } from "../../Interfaces/interface.EndTit";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { EndTitEmpty } from "@/app/GerAdv_TS/Models/EndTit";
import { useWindow } from "@/app/hooks/useWindows";

interface EndTitWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedEndTit?: IEndTit;
    onSuccess: () => void;
    onError: () => void;
}

const EndTitWindow: React.FC<EndTitWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedEndTit,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/endtit/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedEndTit?.id}`);
        }

    }, [isMobile, router, selectedEndTit]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedEndTit?.id ?? 0).toString()}
                >
                    <EndTitInc
                        id={selectedEndTit?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowEndTit: React.FC<EndTitWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <EndTitWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedEndTit={EndTitEmpty()}>
        </EndTitWindow>
    )
};

export default EndTitWindow;