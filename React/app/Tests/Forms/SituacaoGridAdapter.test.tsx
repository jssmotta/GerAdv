// SituacaoGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { SituacaoGridAdapter } from '@/app/GerAdv_TS/Situacao/Adapter/SituacaoGridAdapter';
// Mock SituacaoGrid component
jest.mock('@/app/GerAdv_TS/Situacao/Crud/Grids/SituacaoGrid', () => () => <div data-testid='situacao-grid-mock' />);
describe('SituacaoGridAdapter', () => {
  it('should render SituacaoGrid component', () => {
    const adapter = new SituacaoGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('situacao-grid-mock')).toBeInTheDocument();
  });
});