// PoderJudiciarioAssociadoGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { PoderJudiciarioAssociadoGridAdapter } from '@/app/GerAdv_TS/PoderJudiciarioAssociado/Adapter/PoderJudiciarioAssociadoGridAdapter';
// Mock PoderJudiciarioAssociadoGrid component
jest.mock('@/app/GerAdv_TS/PoderJudiciarioAssociado/Crud/Grids/PoderJudiciarioAssociadoGrid', () => () => <div data-testid='poderjudiciarioassociado-grid-mock' />);
describe('PoderJudiciarioAssociadoGridAdapter', () => {
  it('should render PoderJudiciarioAssociadoGrid component', () => {
    const adapter = new PoderJudiciarioAssociadoGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('poderjudiciarioassociado-grid-mock')).toBeInTheDocument();
  });
});