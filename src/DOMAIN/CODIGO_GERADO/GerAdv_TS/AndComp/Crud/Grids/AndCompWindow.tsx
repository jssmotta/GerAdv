import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import AndCompInc from "../Inc/AndComp";
import { IAndComp } from "../../Interfaces/interface.AndComp";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { AndCompEmpty } from "@/app/GerAdv_TS/Models/AndComp";
import { useWindow } from "@/app/hooks/useWindows";

interface AndCompWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedAndComp?: IAndComp;
    onSuccess: () => void;
    onError: () => void;
}

const AndCompWindow: React.FC<AndCompWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedAndComp,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/andcomp/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedAndComp?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedAndComp]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedAndComp?.id ?? 0).toString()}
                >
                    <AndCompInc
                        id={selectedAndComp?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowAndComp: React.FC<AndCompWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <AndCompWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedAndComp={AndCompEmpty()}>
        </AndCompWindow>
    )
};

export default AndCompWindow;