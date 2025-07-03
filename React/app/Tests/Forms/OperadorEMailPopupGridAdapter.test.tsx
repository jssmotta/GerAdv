// OperadorEMailPopupGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { OperadorEMailPopupGridAdapter } from '@/app/GerAdv_TS/OperadorEMailPopup/Adapter/OperadorEMailPopupGridAdapter';
// Mock OperadorEMailPopupGrid component
jest.mock('@/app/GerAdv_TS/OperadorEMailPopup/Crud/Grids/OperadorEMailPopupGrid', () => () => <div data-testid='operadoremailpopup-grid-mock' />);
describe('OperadorEMailPopupGridAdapter', () => {
  it('should render OperadorEMailPopupGrid component', () => {
    const adapter = new OperadorEMailPopupGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('operadoremailpopup-grid-mock')).toBeInTheDocument();
  });
});